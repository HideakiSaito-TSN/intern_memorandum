using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Memorandum.Models;

namespace Memorandum.Controllers
{
    public class AccountsController : Controller
    {
        private MemorandumDb db = new MemorandumDb();

    // 12/9追加Login
    [HttpGet]
        public ActionResult Login()
        {
          return View();
        }

        [HttpPost]
     public ActionResult Login(Account model)
    {
      Account dbAccount = db.Accounts.Where(a=>a.Name == model.Name).FirstOrDefault();
      if(model != null)
      {
        if(dbAccount.Pass == model.Pass)
        {
          //FormsAuthentication.SetAuthCookie(model.Name, true);
          return RedirectToAction("Index", "Messages");
        }
        else
        {
          return this.View(model);
        }
      }
      else
      {
        return this.View(model);
      }
    }
    //public ActionResult Login(Account model)
    //{
    //  if (model.Name == "intern" && model.Pass == "12345")
    //  {
    //    FormsAuthentication.SetAuthCookie(model.Name, true);
    //   return RedirectToAction("Index", "Home");
    //  }
    //  else
    //  {
    //    return this.View(model);
    //  }
    //}

    public ActionResult Logout()
    {
      //FormsAuthentication.SignOut();
      return RedirectToAction("Login", "Accounts");
    }

    // GET: Accounts
    public ActionResult Index()
        {
            return View(db.Accounts.ToList());
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
    //public ActionResult Create([Bind(Include = "Id,Name,Islogin,Admin")] Account account)
    public ActionResult Create([Bind(Include = "Name,Pass")] Account account)
    {
            if (ModelState.IsValid)
            {
                db.Accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(account);
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "Id,Name,Islogin,Admin")] Account account)
    {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(account);
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
