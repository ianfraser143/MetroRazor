// Global using statements for BlazorApp.Web
using BlazorApp.Web.Data.Models;
using MongoDB.Driver;

namespace BlazorApp.Web.Components.Pages
{
    public partial class Nimz
    {
        private List<Nims>? nimsRecords;
        private bool isLoading = true;
        private string? errorMessage;
        private string? actionMessage;
        private string searchTerm = string.Empty;
        private string statusFilter = "all";
        private Nims? selectedRecord;

        private const int PageSize = 10;
        private int CurrentPage = 1;

        private IEnumerable<Nims> FilteredRecords
        {
            get
            {
                if (nimsRecords == null) return Enumerable.Empty<Nims>();

                return nimsRecords.Where(r =>
                {
                    // Status filter
                    if (statusFilter == "active" && !r.IsActive) return false;
                    if (statusFilter == "inactive" && r.IsActive) return false;

                    // Search term filter
                    if (!string.IsNullOrWhiteSpace(searchTerm))
                    {
                        var term = searchTerm.Trim();
                        var matchCode = r.Code?.Contains(term, StringComparison.OrdinalIgnoreCase) == true;
                        var matchDesc = r.Description?.Contains(term, StringComparison.OrdinalIgnoreCase) == true;
                        var matchPriority = r.Priority?.Contains(term, StringComparison.OrdinalIgnoreCase) == true;
                        var matchId = r._id?.Contains(term, StringComparison.OrdinalIgnoreCase) == true;
                        var matchCat = r.NIMSCategorys?._id?.Contains(term, StringComparison.OrdinalIgnoreCase) == true;
                        var matchType = r.NIMSTypes?._id?.Contains(term, StringComparison.OrdinalIgnoreCase) == true;
                        var matchBranch = r.Branchs?._id?.Contains(term, StringComparison.OrdinalIgnoreCase) == true;

                        return matchCode || matchDesc || matchPriority || matchId || matchCat || matchType || matchBranch;
                    }

                    return true;
                });
            }
        }

        private IEnumerable<Nims> PagedRecords =>
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
                nimsRecords = NimsService.Get();
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



        private void ToggleDetails(Nims record)
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

