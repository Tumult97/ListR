namespace ListR.Common.DatbaseQueries;

public class DatabaseQueries
{
    #region UserGroups
    public static FormattableString UserGroupsGetAllByEmail(string email)
    {
        FormattableString sql = $@"
<<<<<<< HEAD
                    Select distinct
=======
<<<<<<< Updated upstream
                    Select 
=======
                  Select distinct
>>>>>>> Stashed changes
>>>>>>> SVC_Vanguard
                      ug.*,
                      CASE WHEN u.""Id"" is NOT null then
                      1 else 0 end as IsCreator --,
                      --s.*
                     from ""ShopLists"" s
                    left join ""UserGroups"" ug on ug.""Id"" = s.""UserGroupId""
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
    #endregion

    #region ShoppingLists
    public static FormattableString ShopListGetByUserGroupAndEmail(int userGroupId, string userEmail)
    {
        FormattableString sql = $@"select 
                                      u.* 
                                    from ""ShopLists"" sl
                                    left join ""UserGroups"" ug on sl.""UserGroupId"" = ug.""Id""
                                    left join ""UserGroupMappings"" ugm on ug.""Id"" = ugm.""UserGroupsId""
                                    left join ""AspNetUsers"" u on ugm.""UsersId"" = u.""Id""
                                    where sl.""UserGroupId"" = {userGroupId}
                                    and u.""Email"" = '{userEmail}'";

        return sql;
    }
    #endregion
}