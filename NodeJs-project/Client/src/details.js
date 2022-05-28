function run() {
    new Vue({
      el: '#details',
      data: {
        id: 'default',
        phone: {}
      },
      created: function () {

        let uri = window.location.search.substring(1);
        let params = new URLSearchParams(uri);
        this.id = params.get("id");

        axios.get('http://localhost:3000/phones/'+this.id).then(
            (response) => {
                this.phone = response.data;
                console.log(this.phone.Id);
            }
        );
      },
      methods: {

      }
    });
  }
  
  document.addEventListener('DOMContentLoaded', () => {
    run();
  });
  