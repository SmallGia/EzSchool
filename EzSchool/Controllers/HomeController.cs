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
                    // 4.Operator
                    // 5.Teacher
                    // 6.Student
                    string url = string.Empty;
                    if (finduser[0].UserTypeID == 6)
                    {
                        return RedirectToAction("About");
                    }
                    else if (finduser[0].UserTypeID == 4)
                    {
                        return RedirectToAction("About");
                    }
                    else if (finduser[0].UserTypeID == 5)
                    {
                        return RedirectToAction("About");
                    }
                    else if (finduser[0].UserTypeID == 1)
                    {
                        url = "About";
                           
                     //   return RedirectToAction("About");
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
        int userId = Convert.ToInt32(Session["UserID"]);
        var student = GetStudentByUserId(userId);
        var sessionName = db.SessionTables
                    .Where(s => s.SessionID == student.SessionID)
                    .Select(s => s.Name)
                    .FirstOrDefault();
        var className = db.ClassTables
                  .Where(c => c.ClassID == student.ClassID)
                  .Select(c => c.Name)
                  .FirstOrDefault();

        var programName = db.ProgrameTables
                            .Where(p => p.ProgrameID == student.ProgrameID)
                            .Select(p => p.Name)
                            .FirstOrDefault();
        ViewData["Message"] = "Welcome to EzSchool";
        ViewBag.Student = student;
        ViewBag.SessionName = sessionName;
        ViewBag.ClassName = className;
        ViewBag.ProgramName = programName;
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
    private StudentTable GetStudentByUserId(int userId)
    {
        var student = db.StudentTables.FirstOrDefault(s => s.UserID == userId);
        return student;
    }
}
