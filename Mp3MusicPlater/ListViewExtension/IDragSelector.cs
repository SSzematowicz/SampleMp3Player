namespace Mp3MusicPlater
{
    ///<summary>
    ///https://www.codeproject.com/Articles/1092326/WPF-ListView-With-Drag-Selection
    ///</summary>
    public interface IDragSelector
    {
        double ScrollOffset { get; set; }

        double ScrollTolerance { get; set; }

        bool IsDragSelectionEnabled { get; set; }

        Selection Selection { get; set; }
    }
}
