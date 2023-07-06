namespace PluginRepository.Core.Models;

public partial class CommentModel : ObservableObject
{
    [ObservableProperty]
    private string _content;

    [ObservableProperty]
    private UserDisplayModel _user;

    [ObservableProperty]
    private DateTime _createdAt = DateTime.UtcNow;

    public CommentModel(string content, UserModel user)
    {
        _content = content;
        _user = new(user);
    }
}
