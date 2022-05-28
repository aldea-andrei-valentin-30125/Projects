function run() {
    new Vue({
      el: '#update',
      data: {
        id: '',
        message: '',
        phone: {}
      },
      created: function () {

        let uri = window.location.search.substring(1);
        let params = new URLSearchParams(uri);
        this.id = params.get("id");

        axios.get('http://localhost:3000/phones/'+this.id).then(
            (response) => {
                this.phone = response.data;
            }
        );
      },
      methods: {
        update: function(){
            console.dir(this.phone);

            return axios.post('http://localhost:3000/phones/'+ this.id, this.phone).then(
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
  