using CRMLeadWithADO.Data;
using CRMLeadWithADO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace CRMLeadWithADO.Controllers
{
    public class LeadsController : Controller
    {
        // Read the data
        public IActionResult Index()
        {
            List<LeadsEntity> leads = new List<LeadsEntity>();
            LeadRepo leadRepo = new LeadRepo(); 

            leads = leadRepo.GetAllLeads();

            return View(leads);
        }

        // Create the data
        public ActionResult AddLead()
        {
            // Normal View() return a view with the same name as the action method from which it's called
            return View(); 
        }
        public ActionResult AddNewLead(LeadsEntity leads)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(leads.NextFollowUpDate < leads.LeadDate)
                    {
                        ViewBag.Message = "Follow up date cannot be less than lead date";
                        return View("AddLead");
                    }
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

        // Updating the data
        public IActionResult EditLead(int Id)
        {
            LeadsEntity leads = new LeadsEntity();
            LeadRepo leadRepo = new LeadRepo();

            leads = leadRepo.GetLeadById(Id);

            return View(leads);
        }

        public IActionResult EditLeadDetails(int Id, LeadsEntity leads)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (leads.NextFollowUpDate < leads.LeadDate)
                    {
                        ViewBag.Message = "Follow up date cannot be less than lead date";
                        return View("AddLead");
                    }
                    LeadRepo dbLead = new LeadRepo();
                    if (dbLead.EditLeadDetails(Id, leads))
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

        public IActionResult DeleteLead(int Id)
        {
            LeadsEntity leads = new LeadsEntity();
            LeadRepo leadRepo = new LeadRepo();

            leads = leadRepo.GetLeadById(Id);

            return View(leads);
        }

        public IActionResult DeleteLeadDetails(int Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LeadRepo dbLead = new LeadRepo();
                    if (dbLead.DeleteLeadDetails(Id))
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
