﻿using System;
using System.Collections.Generic;
using Counter.ThingsToCount;

namespace Counter
{
  class Program
  {
    static void Main()
    {
      // Some things to count
      var someApples = new List<Apple> {new Apple(), new Apple(), new Apple()};

      var boxOfApples = new Box<Apple>();
      boxOfApples.Add(new Apple());
      boxOfApples.Add(new Apple());

      var cart = new Cart<Apple>();
      cart.Add(boxOfApples);

      // Some counters
      var appleCounter = new Counter<Apple>();
      someApples.ForEach(appleCounter.Add);

      Console.WriteLine(appleCounter.Count); // Should be 3

      var cartCounter = new Counter<Cart<Apple>>();
      cartCounter.Add(cart);

      Console.WriteLine(cartCounter.Count); // Should be 2 (number of apples in the cart in total)

      var anythingCounter = new Counter<ICountable>();
      someApples.ForEach(anythingCounter.Add);
      anythingCounter.Add(cart);

      Console.WriteLine(anythingCounter.Count); // Should be 5 - sum of the above

      Console.ReadLine();
    }
  }
}
