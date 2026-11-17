// Global using statements for BlazorApp.Web
using BlazorApp.Web.Data;
using MongoDB.Driver;

namespace BlazorApp.Web.Components.Pages
{
    public partial class Nimz
    {
        private List<ApplicationNims>? nimsRecords;
        private bool isLoading = true;
        private string? errorMessage;
        private string? actionMessage;
        private string searchTerm = string.Empty;
        private string statusFilter = "all";
        private ApplicationNims? selectedRecord;

        private const int PageSize = 10;
        private int CurrentPage = 1;

        private IEnumerable<ApplicationNims> FilteredRecords
        {
            get
            {
                if (nimsRecords == null) return Enumerable.Empty<ApplicationNims>();

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

        private IEnumerable<ApplicationNims> PagedRecords =>
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
                nimsRecords = await DbContext.GetNimsRecordsAsync();
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

        private async Task SeedExampleDataAsync()
        {
            try
            {
                actionMessage = null;
                errorMessage = null;

                var existing = await DbContext.Nims.Find(x => x._id == "4d0d4c238b4901a698857602").FirstOrDefaultAsync();
                if (existing == null)
                {
                    var sample = ApplicationDbContext.CreateSampleNims();
                    await DbContext.Nims.InsertOneAsync(sample);
                    actionMessage = "Example NIMS record (Code: 1151 - Escort) inserted into MongoDB successfully!";
                }
                else
                {
                    var sample = ApplicationDbContext.CreateSampleNims();
                    sample._id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
                    sample.Description = $"{sample.Description} (Copy)";
                    await DbContext.Nims.InsertOneAsync(sample);
                    actionMessage = $"Additional NIMS record inserted with new ID: {sample._id}";
                }

                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                errorMessage = $"Failed to insert example record into MongoDB: {ex.Message}";
            }
        }

        private void ToggleDetails(ApplicationNims record)
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
