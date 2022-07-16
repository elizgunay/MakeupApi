////let burger = document.querySelector('.burger');
////let navLinks = document.querySelector('.nav-links');
////let header = document.querySelector('.header');
////burger.addEventListener('click', () => {
////    navLinks.classList.toggle('nav-active');
////    header.classList.toggle('header-active')

////})

let index = 0;

function carousel() {
    let slides = document.getElementsByClassName('slide');
    let slideLines = document.getElementsByClassName('line')
    for (let i = 0; i < slides.length; i++) {
        slides[i].style.display = 'none';
    }

    index++;

    if (index > slides.length) {
        index = 1;
    }

    for (let i = 0; i < slideLines.length; i++) {
        slideLines[i].className = slideLines[i].className.replace(" active", "");
    }
    slides[index - 1].style.display = 'block';
    slideLines[index - 1].className += " active"
    setTimeout(carousel, 5000);

}

carousel();