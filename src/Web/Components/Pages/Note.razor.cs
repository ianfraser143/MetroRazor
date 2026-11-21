// Global using statements for BlazorApp.Web
using BlazorApp.Web.Data.Models;
using MongoDB.Driver;

namespace BlazorApp.Web.Components.Pages
{
    public partial class Note
    {
        private List<Notes>? noteRecords;
        private bool isLoading = true;
        private string? errorMessage;
        private string? actionMessage;
        private string searchTerm = string.Empty;
        private string statusFilter = "all";
        private Notes? selectedRecord;

        private const int PageSize = 10;
        private int CurrentPage = 1;

        private IEnumerable<Notes> FilteredRecords
        {
            get
            {
                if (noteRecords == null) return Enumerable.Empty<Notes>();

                return noteRecords.Where(r =>
                {
                    // Status filter
                    if (statusFilter == "active" && !r.IsActive) return false;
                    if (statusFilter == "inactive" && r.IsActive) return false;

                    // Search term filter
                    if (!string.IsNullOrWhiteSpace(searchTerm))
                    {
                        var term = searchTerm.Trim();
                        var matchId = r._id?.Contains(term, StringComparison.OrdinalIgnoreCase) == true;
                        var matchCreate = r.CreateDate?.ToLocalTime().ToString("yyyy-MM-dd HH:mm").Contains(term, StringComparison.OrdinalIgnoreCase) == true;
                        var matchModified = r.ModifiedDate?.ToLocalTime().ToString("yyyy-MM-dd HH:mm").Contains(term, StringComparison.OrdinalIgnoreCase) == true;

                        return matchId || matchCreate || matchModified;
                    }

                    return true;
                });
            }
        }

        private IEnumerable<Notes> PagedRecords =>
            FilteredRecords.Skip((CurrentPage - 1) * PageSize).Take(PageSize);

        private async Task OnPageChanged(int page)
        {
            CurrentPage = page;
            await InvokeAsync(StateHasChanged);
        }

        protected override async Task OnInitializedAsync()
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            isLoading = true;
            errorMessage = null;
            actionMessage = null;

            try
            {
                // Query using NotesService
                noteRecords = NotesService.Get();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            finally
            {
                isLoading = false;
            }
        }

        private void ToggleDetails(Notes record)
        {
            if (selectedRecord?._id == record._id)
            {
                selectedRecord = null;
            }
            else
            {
                selectedRecord = record;
            }
        }

        private void ResetFilters()
        {
            searchTerm = string.Empty;
            statusFilter = "all";
        }

        private static string TruncateId(string? id)
        {
            if (string.IsNullOrEmpty(id)) return "-";
            return id.Length > 10 ? id.Substring(0, 8) + "..." : id;
        }
    }
}

