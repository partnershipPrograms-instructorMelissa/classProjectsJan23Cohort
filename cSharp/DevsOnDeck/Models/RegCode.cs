public class InviteModel {
    private readonly IConfiguration _config;
    public InviteModel(IConfiguration config) {
        _config = config;
    }
    public void OnGet() {
        var InviteCode = _config["Invite:InviteKey"];
    }
}