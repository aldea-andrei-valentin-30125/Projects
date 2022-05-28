function run() {
    new Vue({
      el: '#addPhone',
      data: {
        id: '',
        message: '',
        date: '',
        phone: {}
      },
      created: function () {
        let uri = window.location.search.substring(1);
        let params = new URLSearchParams(uri);
        this.Id = params.get("Id");
        this.date = Date.now();
        this.phone = {"Id":this.Id, "Name":"", "Brand":"", "Price":0, "Discount":0, "Description":"", "Color":"", "DisplayType":"", "RAMmemory":0,"ReleaseDate":"2022-05-21 22:29:29.577"};
      },
      methods: {
        addPhone: function(){
            console.dir(this.phone);

            return axios.put('http://localhost:3000/phones', this.phone).then(
                (response) => {
                    this.message = response.data; // saved
                }
            );


        }
      }
    });
  }
  
  document.addEventListener('DOMContentLoaded', () => {
    run();
  });
  