namespace ListR.Common.DatbaseQueries;

public class DatabaseQueries
{
    public static FormattableString UserGroupsGetAllByEmail(string email)
    {
        FormattableString sql = $@"
                    Select 
                      ug.*,
                      CASE WHEN u.""Id"" is NOT null then
                      1 else 0 end as IsCreator
                     from ""UserGroups"" ug
                    left join ""AspNetUsers"" u on ug.""UserCreatedBy"" = u.""Id""
                    left join ""UserGroupMappings"" ugm on ug.""Id"" = ugm.""UserGroupsId""
                    left join ""AspNetUsers"" u2 on ugm.""UsersId"" = u2.""Id""
                    where u.""Email"" = '{email}' 
                    OR u2.""Email"" = '{email}'
                    ";

        return sql;
    }
    public static FormattableString UserGroupsGetById(int Id)
    {
        FormattableString sql = $@"
                    Select 
                      ug.*
                     from ""UserGroups"" ug
                    left join ""AspNetUsers"" u on ug.""UserCreatedBy"" = u.""Id""
                    Where ug.Id = {Id}
                    ";

        return sql;
    }
}