using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DatabaseAccess;

public class HomeController : Controller
{
    private SchoolMgDbEntities db = new SchoolMgDbEntities();
    public ActionResult Login()
    {
        return View();
    }
    public ActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public ActionResult LoginUser(string email, string password)
    {
        try
        {
            if (email != null && password != null)
            {
                var finduser = db.UserTables.Where(x => x.EmailAddress == email && x.Password == password).ToList();
                if (finduser.Count == 1)
                {
                    Session["UserID"] = finduser[0].UserID;
                    Session["UserTypeID"] = finduser[0].UserTypeID;
                    Session["FullName"] = finduser[0].FullName;
                    Session["UserName"] = finduser[0].UserName;
                    Session["Password"] = finduser[0].Password;
                    Session["ContactNo"] = finduser[0].ContactNo;
                    Session["EmailAddress"] = finduser[0].EmailAddress;
                    Session["Address"] = finduser[0].Address;

                    // 1.Admin 
                    // 2.Operator
                    // 3.Teacher
                    // 4.Student
                    string url = string.Empty;
                    if (finduser[0].UserTypeID == 2)
                    {
                        return RedirectToAction("About");
                    }
                    else if (finduser[0].UserTypeID == 3)
                    {
                        return RedirectToAction("About");
                    }
                    else if (finduser[0].UserTypeID == 4)
                    {
                        return RedirectToAction("About");
                    }
                    else if (finduser[0].UserTypeID == 1)
                    {
                        url = "About";
                    }
                    return RedirectToAction(url);

                }
                else
                {
                    Session["UserID"] = string.Empty;
                    Session["UserTypeID"] = string.Empty;
                    Session["FullName"] = string.Empty;
                    Session["UserName"] = string.Empty;
                    Session["Password"] = string.Empty;
                    Session["ContactNo"] = string.Empty;
                    Session["EmailAddress"] = string.Empty;
                    Session["Address"] = string.Empty;
                    ViewBag.Message = "Invalid Email or Password";
                }
            }
            else
            {
                Session["UserID"] = string.Empty;
                Session["UserTypeID"] = string.Empty;
                Session["FullName"] = string.Empty;
                Session["UserName"] = string.Empty;
                Session["Password"] = string.Empty;
                Session["ContactNo"] = string.Empty;
                Session["EmailAddress"] = string.Empty;
                Session["Address"] = string.Empty;
                ViewBag.Message = "Some unexpected issue is occure please try again!";
            }
        }
        catch (Exception ex)
        {
            Session["UserID"] = string.Empty;
            Session["UserTypeID"] = string.Empty;
            Session["FullName"] = string.Empty;
            Session["UserName"] = string.Empty;
            Session["Password"] = string.Empty;
            Session["ContactNo"] = string.Empty;
            Session["EmailAddress"] = string.Empty;
            Session["Address"] = string.Empty;
            ViewBag.Message = "Some unexpected issue is occure please try again!";
        }
        return View("Login");
    }

    public ActionResult About()
    {
        ViewData["Message"] = "Welcome to EzSchool";
        return View();
    }
    public ActionResult ChangePassword()
    {

        return View();
    }
    public ActionResult ChangePasswordU(string oldpass, string newpass,string confirm)
    {
        if (newpass != confirm)
        {
            ViewBag.Message = "New Password and Confirm Password does not match!";
            return View("ChangePassword");
        }
        int userid = Convert.ToInt32(Convert.ToString(Session["UserID"]));
        var getuser = db.UserTables.Find(userid);
        if (getuser.Password == oldpass.Trim())
        {
            getuser.Password = newpass.Trim();
        }
        else
        {
            ViewBag.Message = "Old Password is not correct!";
            return View("ChangePassword");
        }
        db.Entry(getuser).State = System.Data.Entity.EntityState.Modified;
        db.SaveChanges();
        ViewBag.Message = "Password Changed Successfully!";
        return RedirectToAction("Logout");
    }
    public ActionResult Logout()
    {
        Session["UserID"] = string.Empty;
        Session["UserTypeID"] = string.Empty;
        Session["FullName"] = string.Empty;
        Session["UserName"] = string.Empty;
        Session["Password"] = string.Empty;
        Session["ContactNo"] = string.Empty;
        Session["EmailAddress"] = string.Empty;
        Session["Address"] = string.Empty;
        return RedirectToAction("Login");
    }
}
