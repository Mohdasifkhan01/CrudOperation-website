import React, { Component } from "react";
import TextField from "@material-ui/core/TextField";
import Button from "@material-ui/core/Button";

import "./HomePage.scss";
import CrudServices from '../Services/CrudServices'
const services=new CrudServices();

export default class HomePage extends Component {
  constructor(){
    super();
    this.state={
      UserName:'',
      Age:'',
    }
  }
  componentWillMount(){
    console.log("Component will Mount Calling");
  }
  ReadRecord(){
    CrudServices.
  }
  handleChange=(event)=>{
    const{name,value}=event.target
    this.setState({[name]:value},()=>{
      console.log(this.state)
    })
  }
  handleClick=()=>{
    if(this.state.UserName===''||this.state.Age===''
        ){
      console.log("Input Field Is Empty");
      return;
    }
    console.log("Data:",this.state)
    const data={
      UserName:this.state.UserName,
      age:Number(this.state.Age),
    }
    services.CreateRecord(data).then((data)=>{
      console.log(data)
    }).catch((error)=>{
      console.log(error)
    })
  }
  render() {
    let state =this.state
    return (
      <div className="MainContainer">
        <div className="SubContainer">
          <div className="Box1">
            <div className="Input-Container">
              <div className="flex-Container">
                <TextField
                fullWidth
                  label="UserName"
                  name="UserName"
                  size="small"
                  variant="outlined" 
                  value={state.UserName}
                  onChange={this.handleChange}
                />
              </div>
              <div className="flex-Container">
                <TextField
                fullWidth
                  label="Age"
                  name="Age"
                  size="small"
                  variant="outlined"
                  value={state.Age}
                  onChange={this.handleChange}
                />
              </div>
              <div className="flex-button">
                <Button variant="contained" color="secondary" onClick={this.handleClick}>
                  Submit
                </Button>
              </div>
            </div>
          </div>

          <div className="Box2"></div>
        </div>
      </div>
    );
  }
}
