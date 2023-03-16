namespace BlazorExaplep14.WEBUI.Models
{
    public class PageItem
    {
        public string Text { get; set; }
        public int PageIndex { get; set; }
        public bool Enable { get; set; }
        public bool IsActive { get; set; }

        public PageItem(int pageIndex, bool enable, string text)
        {
            Text = text;
            PageIndex = pageIndex;
            Enable = enable;
        }

    }
}
