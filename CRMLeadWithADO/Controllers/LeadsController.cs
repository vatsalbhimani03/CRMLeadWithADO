using CRMLeadWithADO.Data;
using CRMLeadWithADO.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRMLeadWithADO.Controllers
{
    public class LeadsController : Controller
    {
        public IActionResult Index()
        {
            List<LeadsEntity> leads = new List<LeadsEntity>();
            LeadRepo leadRepo = new LeadRepo(); 

            leads = leadRepo.GetAllLeads();

            return View(leads);
        }


        public ActionResult AddLead()
        {

            return View();
        }

        public ActionResult AddNewLead(LeadsEntity leads)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LeadRepo dbLead = new LeadRepo();
                    if (dbLead.AddLead(leads))
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

    }

}
