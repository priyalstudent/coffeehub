import React from "react";
import { Outlet } from "react-router-dom";

const MainLayout = () => {
  return (
    <div>
      {/*Navbar*/}
      <header>
        <div>
          <h1>CoffeHub</h1>
        </div>
      </header>

      <main>
        <Outlet />
      </main>

      <footer>© CoffeeHub — All rights reserved</footer>
    </div>
  );
};

export default MainLayout;
