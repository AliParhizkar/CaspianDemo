namespace Caspian.UI
{
    public interface IGridRowSelect
    {
        void SelectFirstRow();

        void SelectNextRow();

        void SelectPrevRow();

        void SelectFirstPage();

        int? SelectedRowId { get; }

        void ResetGrid();
    }
}
