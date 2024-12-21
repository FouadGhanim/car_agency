let home_paragraph = document.querySelectorAll(".carousel-inner .content p");
let carousel_inner = document.querySelectorAll(
  ".carousel-inner .carousel-item "
);
let home_title = document.querySelectorAll(".carousel-inner .content h1");
let home_btn = document.querySelectorAll(".carousel-inner .content .btn");

setInterval(function () {
  carousel_inner.forEach((slide, index) => {
    if (slide.classList.contains("active")) {
      home_paragraph.forEach((p, i) => {
        p.classList.remove("animate__bounce");
        p.style.opacity = "0";
        p.style.bottom = "-150px";

        home_title[i].style.transform = "scale(0)";
        home_btn[i].classList.remove("animate__bounceInRight");
      });
      home_paragraph[index].style.opacity = "1";
      home_paragraph[index].classList.add("animate__bounce");
      home_paragraph[index].style.bottom = "0";

      home_title[index].style.transform = "scale(1)";

      home_btn[index].classList.add("animate__bounceInRight");
    }
  });
}, 1);

var swiper = new Swiper(".mySwiper", {
  slidesPerView: 1,
  spaceBetween: 10,
  navigation: {
    nextEl: ".swiper-button-next",
    prevEl: ".swiper-button-prev",
  },
  breakpoints: {
    640: {
      slidesPerView: 1,
      spaceBetween: 20,
    },
    768: {
      slidesPerView: 1,
      spaceBetween: 40,
    },
    1024: {
      slidesPerView: 2,
      spaceBetween: 50,
    },
  },
});
