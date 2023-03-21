#pragma warning disable CS8618
namespace DevsHelpingDevs.Models;

public class MyViews {

// **** User ****
public User user {get; set;}
public List<User> allUsers {get; set;}
public UserProfile userProfile {get; set;}
public List<UserProfile> allUserProfiles {get; set;}
public DevSkill devSkill {get; set;}
public List<DevSkill> AllDevSkills {get; set;}
public PassKey passKey {get; set;}
public List<PassKey> allPassKeys {get; set;}


// **** Job ****
public Skill skill {get; set;}
public List<Skill> allSkills {get; set;}
public Org Org {get; set;}
public List<Org> allOrgs {get; set;}
public OrgProfile  orgProfile {get; set;}
public List<OrgProfile> allOrgProfiles {get; set;}
public Job job {get; set;}
public List<Job> allJobs {get; set;}
public JobSkill jobSkill {get; set;}
public List<JobSkill> AllJobSkills {get; set;}
public OrgKey orgKey {get; set;}
public List<OrgKey> allOrgKeys {get; set;}

// **** Forum ****
public Topic topic {get; set;}
public List<Topic> allTopics {get; set;}
public Post post {get; set;}
public List<Post> allPosts {get; set;}
public Reply reply {get; set;}
public List<Reply> allReplies {get; set;}

}