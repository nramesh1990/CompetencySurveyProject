﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompetencySurveyProject.Controllers
{
    public class UserDashBoardController : Controller
    {
        // GET: UserDashBoard
        public ActionResult Index()
        {
            return View();
        }
    }
}