import React, { Component } from "react";
import BookDataService from "../services/bookService";

export default class AddBook extends Component {
  constructor(props) {
    super(props);
    this.onChangeTitle = this.onChangeTitle.bind(this);
    this.onChangeAuthor = this.onChangeAuthor.bind(this);
    this.onChangeAmazonLink = this.onChangeAmazonLink.bind(this);
    this.saveBook = this.saveBook.bind(this);
    this.newBook = this.newBook.bind(this);

    this.state = {
      id: null,
      title: "",
      author: "",
      amazonlink: "",
      published: false,

      submitted: false
    };
  }

  onChangeTitle(e) {
    this.setState({
      title: e.target.value
    });
  }

  onChangeAuthor(e) {
    this.setState({
      author: e.target.value
    });
  }

  onChangeAmazonLink(e) {
    this.setState({
      amazonlink: e.target.value
    });
  }

  saveBook() {
    var data = {
      title: this.state.title,
      author: this.state.author,
      amazonlink: this.state.amazonlink
    };

    BookDataService.create(data)
      .then(response => {
        this.setState({
          id: response.data.id,
          title: response.data.title,
          author: response.data.author,
          amazonlink: response.data.amazonlink,
          published: response.data.published,
          submitted: true
        });
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  }

  newBook() {
    this.setState({
      id: null,
      title: "",
      author: "",
      amazonlink: "",
      published: false,

      submitted: false
    });
  }

  render() {
    return (
        <div className="submit-form">
          {this.state.submitted ? (
            <div>
              <h4>You submitted successfully!</h4>
              <button className="btn btn-success" onClick={this.newBook}>
                Add
              </button>
            </div>
          ) : (
            <div>
              <div className="form-group">
                <label htmlFor="title">Title</label>
                <input
                  type="text"
                  className="form-control"
                  id="title"
                  required
                  value={this.state.title}
                  onChange={this.onChangeTitle}
                  name="title"
                />
              </div>
  
              <div className="form-group">
                <label htmlFor="description">Author</label>
                <input
                  type="text"
                  className="form-control"
                  id="description"
                  required
                  value={this.state.author}
                  onChange={this.onChangeAuthor}
                  name="description"
                />
              </div>

              <div className="form-group">
                <label htmlFor="description">Amazon Link</label>
                <input
                  type="text"
                  className="form-control"
                  id="amazonlink"
                  required
                  value={this.state.amazonlink}
                  onChange={this.onChangeAmazonLink}
                  name="amazonlink"
                />
              </div>
  
              <button onClick={this.saveBook} className="btn btn-success">
                Submit
              </button>
            </div>
          )}
        </div>
      );
  }
}