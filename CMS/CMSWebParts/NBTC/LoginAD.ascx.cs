using System;
using System.Data;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CMS.Helpers;
using CMS.PortalEngine.Web.UI;
using CMS.Membership;
using CMS.Base;
using CMS.SiteProvider;
using CMS.EventLog;
using CMS.Localization;
using Custom.SDB;

public partial class CMSWebParts_NBTC_LoginAD : CMSAbstractWebPart
{
    #region "Properties"



    #endregion


    #region "Methods"

    /// <summary>
    /// Content loaded event handler.
    /// </summary>
    public override void OnContentLoaded()
    {
        base.OnContentLoaded();
        SetupControl();
    }


    /// <summary>
    /// Initializes the control properties.
    /// </summary>
    protected void SetupControl()
    {
        if (this.StopProcessing)
        {
            // Do not process
        }
        else
        {

        }
    }


    /// <summary>
    /// Reloads the control data.
    /// </summary>
    public override void ReloadData()
    {
        base.ReloadData();

        SetupControl();
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        //get culture-code ˹�ҷ������׹���� Ẻ auto
        //pass ������ function set ���ҵ�� culture
        SetResource(LocalizationContext.CurrentCulture.CultureCode); 
    }

    private void SetResource(string cultureCode) 
    {
        //���¡ api ���ʹ֧��� text ��� key ���� culture
        lblUser.Text = ResHelper.GetString("user", cultureCode);
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {


        #region
        string user = txtUser.Text.Trim();
        string pass = txtPass.Text.Trim();
        if (CallAD(user, pass))
        {

            try
            {

                UserInfo searchUser = UserInfoProvider.GetUserInfo(user);
                if (searchUser != null)
                {
                    //find
                    AuthenticationHelper.AuthenticateUser(user, true);
                }
                else
                {
                    CreateUser(user);
                    AuthenticationHelper.AuthenticateUser(user, true);

                }
            }
            catch (Exception ex)
            {
                UtilityHelper.LogEvent($"ex.Message=>{ex.Message}");
            }
        }
        #endregion

    }

    private bool CallAD(string user, string pass)
    {
        try
        {
            if (user == "surapong.test@gmail.com" && pass == "1234")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            UtilityHelper.LogEvent($"ex.Message=>{ex.Message}");
            return false;
        }
    }

    private bool CreateUser(string user)
    {
        try
        {
            UserInfo newUser = new UserInfo();


            newUser.FullName = user;
            newUser.UserName = user;
            newUser.Email = user;
            newUser.PreferredCultureCode = "en-us";

            newUser.Enabled = true;
            newUser.IsExternal = true;

            newUser.SiteIndependentPrivilegeLevel = UserPrivilegeLevelEnum.Editor;


            UserInfoProvider.SetUserInfo(newUser);

            return true;
        }
        catch (Exception ex)
        {
            UtilityHelper.LogEvent($"ex.Message=>{ex.Message}");
            return false;
        }
    }
}