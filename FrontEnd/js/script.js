
var arr = document.querySelectorAll(".btn--show");
for(var i=0; i< arr.length; i++){
document.querySelector(".btn--show").addEventListener("click", function(e){
    
    
      if(e.target.matches('.btn')){
      var id  = e.target.id;
      id = id.substr(4, 1);
      console.log(id);
      if(id ==1){

        document.querySelector("#btn-2").classList.add("btn--active");
        document.querySelector("#btn-1").classList.remove("btn--active");
      } else {
        document.querySelector("#btn-2").classList.remove("btn--active");
        document.querySelector("#btn-1").classList.add("btn--active");
        
      }
      document.querySelector(".tools").classList.toggle("tools--active");
    }
});
}