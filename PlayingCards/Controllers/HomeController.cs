﻿using PlayingCards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayingCards.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Deck deck = new Deck();
            return View("Index",deck);
        }

        [HttpPost]
        public ActionResult Shuffle(Deck deck)
        {
            deck.Shuffle();
            return View("Index", deck);
        }

        [HttpGet]
        public ActionResult Shuffle()
        {
            Deck deck = new Deck();
            deck.Shuffle();
            return View("Index",deck);
        }

        [HttpPost]
        public ActionResult Sort(Deck deck)
        {
            deck.Sort();
            return View("Index", deck);
        }

        [HttpGet]
        public ActionResult Sort()
        {
            Deck deck = new Deck();
            deck.Sort();
            return View("Index", deck);
        }
    }
}