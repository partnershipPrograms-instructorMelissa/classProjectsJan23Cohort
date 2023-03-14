#pragma warning disable CS8618
namespace DevsOnDeck.Models;

public class MyViews {
    // **** User
    public User User {get;set;}
    public List<User> allUsers {get;set;}
    public UserProfile UserProfile {get;set;}
    public List<UserProfile> allUserProfile {get;set;}

    // **** Dev
    public Dev Dev {get;set;}
    public List<Dev> allDevs {get;set;}
    public DevSkill DevSkill {get;set;}
    public List<DevSkill> DevSkills {get;set;}

    // **** Org
    public Org Org {get;set;}
    public List<Org> allOrgs {get;set;}

    public OrgProfile OrgProfile {get;set;}
    public List<OrgProfile> allOrgProfiles {get;set;}

    // **** Job
    public Job Job {get;set;}
    public List<Job> allJobs {get;set;}
    public JobSkill JobSkill {get;set;}
    public List<JobSkill> allJobSkills {get;set;}

    // **** Skill
    public Skill Skill {get;set;}
    public List<Skill> allSkills {get;set;}

    // **** OrgMembers
    public OrgList OrgList {get;set;}
    public List<OrgList> allOrgLists {get;set;}

    // **** Admin
    public RandKey RandKey {get; set;}
    public List<RandKey> allKeys {get; set;}
}