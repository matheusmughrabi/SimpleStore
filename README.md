# SimpleStore



<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]


<!-- ABOUT THE PROJECT -->
## About The Project

SimpleStore is a project which I created to practice design patterns and buildin loosely coupled systems. It contains some basic Register/Login functionality which I implemented mostly from scratch (except for the
password hasher), although in the future I intend to use some third-party library to make it more secure. Once the user is registered, he can login to his account, deposit cash to it (and make withdrawals) so that he can purchase products from the store.

So far, the user interface is just a basic ConsoleUI, but I'll will be implementing a WPF UI in the next few days. I chose to build just a ConsoleUI so that I could focuse a bit more in the Domain and Data Access Layer first, also this will serve me as test to see if these layers were implemented in a nicely reusable way.

I'm using SqlServer on my local machine as a database, but I'll implement the same funcionalities in Sqlite so that the app can have a portable db (I already implemented the Users table, but not much else yet). 


<!-- CONTACT -->
## Contact

Matheus Campanini Mughrabi - matheus.mughrabi@gmail.com
