using Bitministry.Business;
using Bitministry.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserDataEntry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        trShowGrid.Visible = false;
        lblMessage.Text = String.Empty;
        if (!IsPostBack)
        {
            FillUserDD();
        }
    }

    private void FillUserDD()
    {
        BusinessClass objBusiness = new BusinessClass();
        String flag = "All";
        List<UserInfo> objGetAllUser = objBusiness.GetAllUser(flag);
        ddlUserName.DataTextField = "UserName";
        ddlUserName.DataValueField = "UserID";
        ddlUserName.DataSource = objGetAllUser;
        ddlUserName.DataBind();
        ddlUNameTransfer.DataTextField = "UserName";
        ddlUNameTransfer.DataValueField = "UserID";
        ddlUNameTransfer.DataSource = objGetAllUser;
        ddlUNameTransfer.DataBind();
    }
    protected void btnDepositeAmount_Click(object sender, EventArgs e)
    {
            if ((txtAmount.Text.Trim() == String.Empty))
            {
                lblMessage.Text = "Please Enter Amount to Deposit.";
                return;
            }
            if ((decimal.Parse(txtAmount.Text.Trim()) <= 0))
            {
                lblMessage.Text = "Please Enter Amount greater then 0.";
                return;
            }
            UserInfo objUserDeatil = new UserInfo();
            objUserDeatil.UserID = Convert.ToInt32(ddlUserName.SelectedValue);
            objUserDeatil.Amount = Decimal.Parse(txtAmount.Text.Trim());
            BusinessClass objBusiness = new BusinessClass();
            int iResult = objBusiness.DepositeAmount(objUserDeatil);
            if (iResult >= 1)
            {
                lblMessage.Text = "Amount Deposited.";
                txtAmount.Text = String.Empty;
            }
        
    }
    protected void btnCurrentBalance_Click(object sender, EventArgs e)
    {
        UserInfo objUserDeatil = new UserInfo();
        objUserDeatil.UserID = Convert.ToInt32(ddlUserName.SelectedValue);
        BusinessClass objBusiness = new BusinessClass();
        decimal iResult = objBusiness.GetCurrentBalance(objUserDeatil);
        lblMessage.Text = "Your Total Balance is : " + iResult.ToString();
    }
    protected void btnGetStatement_Click(object sender, EventArgs e)
    {
        UserInfo objUserDeatil = new UserInfo();
        objUserDeatil.UserID = Convert.ToInt32(ddlUserName.SelectedValue);
        BusinessClass objBusiness = new BusinessClass();
        List<UserInfo> objGetAllUser = objBusiness.GetStatement(objUserDeatil);
        if (objGetAllUser.Count > 0)
        {
            trShowGrid.Visible = true;
            grdStatement.DataSource = objGetAllUser;
            grdStatement.DataBind();
        }
        else
        {
            lblMessage.Text = "No Data Found.";
        }
    }
    protected void btnTransfer_Click(object sender, EventArgs e)
    {
        if (ValidateDataforTransfer())
        {
            UserInfo objUserDeatil = new UserInfo();
            objUserDeatil.UserID = Convert.ToInt32(ddlUserName.SelectedValue);
            objUserDeatil.TransferUserID = Convert.ToInt32(ddlUNameTransfer.SelectedValue);
            objUserDeatil.Amount = Decimal.Parse(txtAmount.Text.Trim());
            BusinessClass objBusiness = new BusinessClass();
            int iResult = objBusiness.TransferAmount(objUserDeatil);
            if (iResult >= 1)
            {
                lblMessage.Text = "Amount Transfer.";
                txtAmount.Text = String.Empty;
            }
            else
            {
                lblMessage.Text = "Unable to Transfer,either balance is less then or equal to 0  or Transfer amount is greater then Balance amount.";
            
            }
        }
    }

    private bool ValidateDataforTransfer()
    {
        lblMessage.Text = String.Empty;
        if (ddlUserName.SelectedValue == ddlUNameTransfer.SelectedValue)
        {
            lblMessage.Text = "Please select different User to Transfer.";
            return false;
        }
        if ((txtAmount.Text.Trim() == String.Empty))
        {
            lblMessage.Text = "Please Enter Amount to Transfer.";
            return false;
        }
        if ((decimal.Parse(txtAmount.Text.Trim()) <= 0))
        {
            lblMessage.Text = "Please Enter Amount greater then 0.";
            return false;
        }
        return true;
    }
    protected void btnWithdraw_Click(object sender, EventArgs e)
    {
        if ((txtAmount.Text.Trim() == String.Empty))
        {
            lblMessage.Text = "Please Enter Amount to Withdraw.";
            return;
        }
        if ((decimal.Parse(txtAmount.Text.Trim()) <= 0))
        {
            lblMessage.Text = "Please Enter Amount greater then 0.";
            return;
        }
        UserInfo objUserDeatil = new UserInfo();
        objUserDeatil.UserID = Convert.ToInt32(ddlUserName.SelectedValue);
        objUserDeatil.Amount = Decimal.Parse(txtAmount.Text.Trim());
        BusinessClass objBusiness = new BusinessClass();
        int iResult = objBusiness.WithdrawAmount(objUserDeatil);
        if (iResult >= 1)
        {
            lblMessage.Text = "Amount Withdrawal.";
            txtAmount.Text = String.Empty;
        }
        else
        {
            lblMessage.Text = "Amount Withdrawal is greater then the balance amount.";
        }
        

    }
}