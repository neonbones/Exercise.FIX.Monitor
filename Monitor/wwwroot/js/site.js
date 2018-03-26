// Write your Javascript code.
$(document).ready(function() { 
    var loader = $('#loader');
    $("#ufa").click(function() { 
        $("DIV#belor").hide();   
        $("DIV#zilair").hide();  
        $("DIV#katav").hide();  
        $("DIV#miass").hide();  
        $("DIV#ufa").show();    
    }); 
    $("#belor").click(function() {  
         loader.show();
        $("DIV#ufa").hide(); 
        $("DIV#zilair").hide();  
        $("DIV#katav").hide();  
        $("DIV#miass").hide();                           
        $("DIV#belor").show();
        loader.hide();
   
    });
    $("#zilair").click(function() {    
        loader.show();                                    
        $("DIV#ufa").hide(); 
        $("DIV#belor").hide();  
        $("DIV#katav").hide();  
        $("DIV#miass").hide();  
        $("DIV#zilair").show();
        loader.hide();
    });
    $("#katav").click(function() {    
        loader.show();  
        $("DIV#ufa").hide(); 
        $("DIV#belor").hide();  
        $("DIV#zilair").hide();  
        $("DIV#miass").hide();                        
        $("DIV#katav").show();
        loader.hide();

    });
    $("#miass").click(function() {   
        loader.show();
        $("DIV#ufa").hide(); 
        $("DIV#zilair").hide();  
        $("DIV#katav").hide();  
        $("DIV#belor").hide();                           
        $("DIV#miass").show();
        loader.hide();
   
    });


    $(".nav a").on("click", function(){
        $(".nav").find(".active").removeClass("active");
        $(this).parent().addClass("active");
        });

    });
