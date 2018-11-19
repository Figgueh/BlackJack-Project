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

        public IActionResult continueGame()
        {
            //Clear the game data
            game.reset();

            //new deck
            playingCards = new Deck();

            return View("Index", game);
        }

        [HttpPost]
        public IActionResult Index(int bet)
        {
            //Apply the bet rules
            if (game.Player.Balance > 0)
            {
                if (game.Player.Balance < bet)
                {
                    ViewData["error"] = "Insufficient Funds!";
                }
                game.checkBet(bet);
            }
            else
                ViewData["error"] = "You dont have anything else to bet!";

            //Send the amount to bet to the view?
            return View(game);
        }

        [HttpPost]
        public IActionResult Play()
        {
            //Give two cards to the dealer.
            game.Dealer.addCardToHand(playingCards.DeckList);
            game.Dealer.addCardToHand(playingCards.DeckList);


            //Give two cards to the player.
            game.Player.addCardToHand(playingCards.DeckList);
            game.Player.addCardToHand(playingCards.DeckList);

            //Check to see if anyone got blackjack
            if(game.Player.HandValue == 21 || game.Dealer.HandValue == 21)
                game.checkState();

            return View(game);
        }

        [HttpPost]
        public IActionResult Action(string choice)
        {
            if (choice == "Hit")
                game.Player.addCardToHand(playingCards.DeckList);

            if (game.Player.HandValue > 21)
                game.checkState();
          
            if (choice == "Stand")
            {
                game.Dealer.dealersTurn(playingCards.DeckList);
                game.checkState();
            }

            return View("Play", game);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
