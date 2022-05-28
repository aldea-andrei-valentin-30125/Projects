
var array = ["nume0","nume1","nume2","nume3","nume4"];
var img = ["images/1.png","images/2.png","images/3.png","images/6.png","images/6.png"];


//aici apar atatea elemente cate vrei tu
for(var i=0;i<5;i++)
{
 
        var aux = '<div class="u-container-style u-list-item u-repeater-item u-white u-list-item-6"><div class="u-container-layout u-similar-container u-container-layout-6"><img class="u-expanded-width u-image u-image-default u-image-6" src=';
        //"images/6.png" 
        aux3 =' alt="" data-image-width="1536" data-image-height="960"><h5 class="u-text u-text-default u-text-16">';
        aux2 =  '</h5><div class="orice"> <a href="https://nicepage.com/c/text-website-templates" class="u-border-none u-btn u-button-style u-hover-palette-1-light-1 u-palette-1-dark-1 u-btn-2">view products</a><h4 class="u-text u-text-default u-text-palette-1-base u-text-6"><label class="like"><input type="checkbox"/><div class="hearth"/></label></h4></div></div></div>';
        var final = aux + img[i]+aux3 + array[i] + aux2;   
        var newDiv = $(final);
        $('#aici').append(newDiv);
  
}



