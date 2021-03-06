function run() {
  let indexComponent = new Vue({
    el: '#app',
    data: {
      phones: [],
      usersService: null,
      message: ''
    },
    created: function () {
      this.usersService = users();
      this.usersService.get().then(response => (this.phones = response.data));
    },
    methods: {
      deletePhone: function(id) {
        console.log('HTTP DELETE spre backend, phone: '+id);
        this.usersService.remove(id).then(response => {
          this.usersService.get().then(response => (this.phones = response.data));  
        });
      },
    }
  });

  indexComponent.use(VueMaterial);

}

document.addEventListener('DOMContentLoaded', () => {
  run();
});
