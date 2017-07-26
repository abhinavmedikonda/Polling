using Polling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.IO;
using Polling.Repositories.IRepositories;

namespace Polling.Controllers
{
    public class HomeController : Controller
    {
        private IPollRepository _IPollRepository;
        private IItemRepository _IItemRepository;
        private IVoteRepository _IVoteRepository;

        public HomeController(IPollRepository theIPollRepository, IItemRepository theIItemRepository, IVoteRepository theIVoteRepository)
        {
            this._IPollRepository = theIPollRepository;
            this._IItemRepository = theIItemRepository;
            this._IVoteRepository = theIVoteRepository;
        }

        public ActionResult Index()
        {
            return View(this._IPollRepository.GetPollS());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CreatePoll()
        {
            Poll poll = new Poll {
                Items = new List<Item>
                {
                    new Item(),
                    new Item()
                }
            };

            return View(poll);
        }

        [HttpPost]
        public ActionResult CreatePoll(Poll poll)
        {
            if (!ModelState.IsValid)
            {
                return View(poll);
            }

            this._IPollRepository.Add(poll);

            return RedirectToAction("Index");
        }

        public ActionResult SharePoll(int pollId, string emailAdress)
        {
            if (string.IsNullOrEmpty(emailAdress))
            {
                return RedirectToAction("Poll", new { id = pollId });
            }

            string emailBody = RenderViewToString(this.ControllerContext, "_PollPartial", this._IPollRepository.GetPoll(pollId));

            SMTPEngine.SendEmail(emailAdress, emailBody);

            return RedirectToAction("Poll", new { id = pollId });
        }

        public ActionResult DeletePoll(int pollId)
        {
            this._IPollRepository.Remove(pollId);

            return RedirectToAction("Index");
        }

        public ActionResult AddItem(int pollId, string itemName)
        {
            if (string.IsNullOrEmpty(itemName))
            {
                return RedirectToAction("Poll", new { id = pollId });
            }

            this._IItemRepository.Add(new Item { Name = itemName, PollId = pollId });

            return RedirectToAction("Poll", new { id=pollId });
        }

        //public ActionResult ItemRow()
        //{
        //    return PartialView("_ItemPartial", new Item());
        //}

        public ActionResult Poll(int id)
        {
            string userId = User.Identity.GetUserId();

            List<Item> itemS = this._IItemRepository.GetItemSByPollId(id);

            ViewBag.Poll = this._IPollRepository.GetPoll(id).Name;

            List<PollViewModel> pollViewModelS = new List<PollViewModel>();

            foreach (Item item in itemS)
            {
                PollViewModel pollViewModel = new PollViewModel();

                pollViewModel.Id = item.Id;
                pollViewModel.PollId = item.PollId;
                pollViewModel.Name = item.Name;
                pollViewModel.IsChecked = item.Votes.Where(x => x.AspNetUserId == User.Identity.GetUserId()).Count() == 0 ? false : true;

                pollViewModel.Votes = item.Votes;

                pollViewModelS.Add(pollViewModel);
            }

            return View(pollViewModelS);
        }

        public ActionResult Vote(List<PollViewModel> pollViewModelS)
        {
            string userId = User.Identity.GetUserId();

            foreach (PollViewModel pollViewModel in pollViewModelS)
            {
                if(this._IVoteRepository.GetVoteByItemId(pollViewModel.Id, userId) == null)
                {
                    if (pollViewModel.IsChecked)
                    {
                        this._IVoteRepository.Add(new Vote
                        {
                            AspNetUserId = userId,
                            ItemId = pollViewModel.Id
                        });
                    }
                }
                else
                {
                    if (!pollViewModel.IsChecked)
                    {
                        this._IVoteRepository.Remove(pollViewModel.Id, userId);
                    }
                }
            }

            return RedirectToAction("Poll", new { id = pollViewModelS.First().PollId });
        }

        public ActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }

        private static string RenderViewToString(ControllerContext context, string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = context.RouteData.GetRequiredString("action");

            var viewData = new ViewDataDictionary(model);

            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(context, viewName);
                var viewContext = new ViewContext(context, viewResult.View, viewData, new TempDataDictionary(), sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }
    }
}