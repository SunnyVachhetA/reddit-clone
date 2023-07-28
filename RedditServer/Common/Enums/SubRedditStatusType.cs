namespace Common.Enums;
public enum SubRedditStatusType : byte
{
    Deleted = EntityStatusType.Deleted,
    Active = EntityStatusType.Active,
    InActive = EntityStatusType.InActive,
    Blocked = 4,
    Banned = 5
}
