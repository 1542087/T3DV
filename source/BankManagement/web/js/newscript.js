/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

$(document).ready(function(){

    $('#nlk-search-str').on('keydown', function(e) {
       if (e.which == 13 || event.keyCode == 13 ){
           $('#nlk-search-submit').trigger('click');
       }
    });

    $('#nlk-search-methods').on('keydown', function(e) {
       if (e.which == 13 || event.keyCode == 13 ){
           $('#nlk-search-submit').trigger('click');
       }
    });


    $('.nlk-search-type').on('click', function(){
        var targetSite = $(this).data('value');
        var searchAction = $(this).data('action');
        var searchParam = $(this).data('param');
        var searchTarget = $(this).data('target');        
       
       $('#nlk-search-str').attr('name', searchParam);
       $('#nlk-search-form').attr('action', searchAction);
       $('#nlk-search-form').attr('target', searchTarget);
       $('#nlk-search-str').attr('placeholder',targetSite);
    });


    $('#nlk-search-submit').on('click', function(){
       var searchStr = $('#nlk-search-str').val();
       if (!searchStr || searchStr == '') {
           $('#nlk-search-str').attr('placeholder','Mã Khách Hàng');
       } else {
           $('#nlk-search-form').submit();
       }
    });
  
    
}); 
$(document).ready(function(){
    //Handles menu drop down
    $('.dropdown-menu').find('form').click(function (e) {
        e.stopPropagation();
    });
});


