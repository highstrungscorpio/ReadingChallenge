import React, { Component } from 'react';
import { Switch, Route, Link } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import "./App.css";

import AddBook from "./components/addBook";
import Book from "./components/bookDetails";
import ListBooks from "./components/listBooks";

class App extends Component {
  render() {
    return (
      <div>
        <nav className="navbar navbar-expand navbar-dark bg-dark">
          <a href="/books" className="navbar-brand">
            Reading Challenge 2021
          </a>
          <div className="navbar-nav mr-auto">
            <li className="nav-item">
              <Link to={"/books"} className="nav-link">
                Books
              </Link>
            </li>
            <li className="nav-item">
              <Link to={"/add"} className="nav-link">
                Add
              </Link>
            </li>
          </div>
        </nav>

        <div className="container mt-3">
          <Switch>
            <Route exact path={["/", "/book"]} component={ListBooks} />
            <Route exact path="/add" component={AddBook} />
            <Route path="/book/:id" component={Book} />
          </Switch>
        </div>
      </div>
    );
  }
}

export default App;