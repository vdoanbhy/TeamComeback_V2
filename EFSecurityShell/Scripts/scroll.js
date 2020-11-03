var toTop = document.querySelector(".to-top"); //access the class="to-top"


//add function scroll() to scroll event
window.addEventListener("scroll", function scroll() {
    //decision structure to add and remove class="active" when scroll pass 100px
    if (window.pageYOffset > 100) {
        toTop.classList.add("active");
    } else {
        toTop.classList.remove("active");
    }
})