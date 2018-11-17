using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlackJackProject.Models;
using Microsoft.AspNetCore.Http;

namespace BlackJackProject.Controllers
{
    public class HomeController : Controller
    {
        static BlackJack game = new BlackJack();
        static Deck playingCards = new Deck();

        public IActionResult Index()
        {
            return View(game);
        }

        [HttpPost]
        public IActionResult Index(int bet)
        {
            //Apply the bet rules
            if (game.Player.Balance > 0)
            {
                game.checkBet(bet);

                //Validation
                if (game.Player.Balance < bet)
                    ViewData["error"] = "Insufficient Funds!";
            }
            else
            {
                ViewData["error"] = "You dont have anything else to bet!";
            }

            //Send the amount to bet to the view?
            return View(game);
        }

        [HttpPost]
        public IActionResult Play(string betamount)
        {
            int bet = Convert.ToInt32(betamount);

            //Give two cards to the dealer.
            game.Dealer.addCardToHand(playingCards.DeckList);
            game.Dealer.addCardToHand(playingCards.DeckList);


            return View(game);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
