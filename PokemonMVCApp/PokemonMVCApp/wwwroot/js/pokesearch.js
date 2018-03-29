function pokeSearch(){
    var options = {
      valueNames: [ 'name', 'id', 'type']
    };

    var userList = new List('search-area', options);

    $('[data-toggle="tooltip"]').tooltip(); 
 }