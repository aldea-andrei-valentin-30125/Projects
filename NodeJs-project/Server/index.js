const dboperations = require('./dboperations');
const { getPhone, getPhones, deletePhone, addPhone } = require('./dboperations');
var api = require('./src/api.js').app;
const fs = require('fs');
const Phone = require('./phone');

newPhone = new Phone(1,"A50","Samsung",1232.54,10.2,"Black","Ceva despre telefon","OLED",4,new Date());

api.get('/', function (request, response) {
    response.json('NodeJS REST API');
  });

api.get('/phones', function (request, response) {
    dboperations.getPhones().then(result => {
        response.json(result[0]);
     })

  });

  api.get('/phones/:id', function (request, response) {
    dboperations.getPhone(request.params.id).then(result => {
        response.json(result[0]);
     })
  }); 

  api.put('/phones', function (request, response) {
    dboperations.addPhone(request.body).then(result => {
        response.json('Phone added successfully');
     })
  });
  
  api.delete('/phones/:id', function (request, response) {
    dboperations.deletePhone(request.params.id).then(result => {
        response.json('Phone with index ' + request.params.id + ' was deleted');
     }) 
  });

  api.post('/phones/:id', function (request, response) {
    dboperations.updatePhone(request.body).then(result => {
        response.json('Phone with index ' + request.params.id + ' was updated');
     }) 
  });

api.listen(3000, function () {
    console.log('Server running @ localhost:3000');
  });

