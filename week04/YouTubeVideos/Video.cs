namespace YouTubeVideos;

public class Video
{
    private string _title;
    private string _author;
    private int _length; // seconds
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public string DisplayVideoInformation()
    {
        int minutes = _length / 60;
        int seconds = _length % 60;
        
        string videoInfo = $"{_title} by {_author} ({minutes}:{seconds})";
        
        string listComments = _comments.Count > 0 
            ? string.Join("\n", _comments.Select(c => c.GetUserComment())) 
            : "No comments";
        
        return $"=== Video ===\n\n{videoInfo}\n\n" +
               $"=== COMMENTS {GetNumberOfComments()} ===" +
               $"\n\n{listComments}";
    }
}