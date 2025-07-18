
# Exchange Web Scraper

> This project is created for educational purposes only. It demonstrates how to scrape daily currency exchange rates from a public banking website using C# and HtmlAgilityPack.

## Overview

This C# console application fetches exchange rate data (such as EUR, USD, GBP) from the Attijariwafa Bank’s public currency rate page. It uses the `HtmlAgilityPack` library to parse HTML content and extract relevant currency values based on specific keywords.

## Features

- Automatically fetches the previous day’s currency exchange rates.
- Extracts only the target currencies: `EURO`, `DOLLARS USD`, and `LIVRE STERLING`.
- Handles dynamic table structures by identifying columns by header names.
- Ensures locale compatibility (decimal separators) for numeric conversion.

## Technologies Used

- C#
- .NET 8 Console App
- HtmlAgilityPack
- System.Threading
- System.Linq

## How It Works

1. Builds a URL with the previous day’s date and encodes it.
2. Sends a request to the exchange rate page.
3. Parses the HTML structure to locate the `thead` and `tr` elements.
4. Identifies column indexes dynamically by header names (`libellé`, `vente`).
5. Prints the filtered exchange rates to the console.




