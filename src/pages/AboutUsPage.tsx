import React from "react";
import CoffeesInlineImage from "../../public/CoffeesInline.png";
import freezeVsSpray from "../../public/freezedriedcoffee.jpg";

const AboutUsPage = () => {
  return (
    <div className="max-w-5xl mx-auto px-4 py-16">
      <div className="w-full h-[320px] overflow-hidden m-6">
        <img
          src={CoffeesInlineImage}
          alt="About CoffeeHub"
          className="w-full h-full object-cover rounded-xl"
        />
      </div>
      <h1 className="text-3xl font-bold mb-6 ">About CoffeeHub</h1>
      <p className="text-gray-700 mb-4">
        CoffeeHub is dedicated to delivering premium-quality coffee crafted with
        care. We source ethically, roast freshly, and package our coffee to
        ensure maximum flavor in every cup.
      </p>
      <p className="text-gray-700 mb-4">
        From classic espresso blends to unique flavored coffees, our goal is to
        bring café-quality experiences straight to your home.
      </p>
      <p className="text-gray-700">
        Whether you are a casual coffee drinker or a true coffee enthusiast,
        CoffeeHub is here to fuel your day.
      </p>
      <div className="bg-[#F6EFE8] py-8 px-4 mt-16 max-w-4xl mx-auto ">
        <div className="px-4 grid grid-cols-1 md:grid-cols-2 gap-10 items-center">
          <div>
            <h2 className="text-2xl font-bold mb-4">
              Interesting Coffee Fact ☕
            </h2>

            <p className="text-gray-700 mb-4">
              Did you know that the way instant coffee is dried plays a huge
              role in its taste, aroma, and quality?
            </p>

            <ul className="space-y-3 text-gray-700">
              <li>
                <strong>Freeze-Dried Coffee:</strong> Preserves natural aroma
                and flavor by freezing the coffee before removing moisture.
                Produces premium, light coffee crystals.
              </li>
              <li>
                <strong>Spray-Dried Coffee:</strong> Uses hot air to quickly dry
                coffee into a fine powder. Faster and cheaper, but less
                aromatic.
              </li>
            </ul>
          </div>

          <div className="w-full h-[260px] rounded-lg overflow-hidden shadow">
            <img
              src={freezeVsSpray}
              alt="Freeze dried vs spray dried coffee"
              className="w-full h-full object-cover"
            />
          </div>
        </div>
      </div>
    </div>
  );
};

export default AboutUsPage;
