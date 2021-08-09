const menu_club = document.getElementById('menu_club')
const header_club = document.getElementById('header_club')
const menu_team = document.getElementById("menu_team")
const header_team = document.getElementById("header_team")
const menu_statistic = document.getElementById("menu_statistic")
const header_statistic = document.getElementById("header_statistic")
const menu_multimedia = document.getElementById("menu_multi")
const header_multimedia = document.getElementById("header_multi")
const footer = document.getElementById("footer")

function club_start() {
    header_club.onmouseover = () => {
        menu_club.style.display = "block";
        header_club.fontSize = "1.8em";
    }
    header_club.onmouseout = () => {
        menu_club.style.display = "none";
        header_club.fontSize = "1.5em";

    }
    menu_club.onmouseover = () => {
        menu_club.style.display = "block";
        header_club.fontSize = "1.8em";
    }
    menu_club.onmouseout = () => {
        menu_club.style.display = "none";
        header_club.fontSize = "1.5em";

    }

    

}
function team_start() {
    header_team.onmouseover = () => {
        menu_team.style.display = "block";
        header_team.fontSize = "1.8em";
    }
    header_team.onmouseout = () => {
        menu_team.style.display = "none";
        header_team.fontSize = "1.5em";

    }
    menu_team.onmouseover = () => {
        menu_team.style.display = "block";
        header_team.fontSize = "1.8em";
    }
    menu_team.onmouseout = () => {
        menu_team.style.display = "none";
        header_team.fontSize = "1.5em";

    }
}
function statistic_start() {
    header_statistic.onmouseover = () => {
        menu_statistic.style.display = "block";
        header_statistic.fontSize = "1.8em";
    }
    header_statistic.onmouseout = () => {
        menu_statistic.style.display = "none";
        header_club.fontSize = "1.5em";

    }
    menu_statistic.onmouseover = () => {
        menu_statistic.style.display = "block";
        header_club.fontSize = "1.8em";
    }
    menu_statistic.onmouseout = () => {
        menu_statistic.style.display = "none";
        header_statistic.fontSize = "1.5em";

    }
}
function multimedia_start() {
    header_multimedia.onmouseover = () => {
        menu_multimedia.style.display = "block";
        header_multimedia.fontSize = "1.8em";
    }
    header_multimedia.onmouseout = () => {
        menu_multimedia.style.display = "none";
        header_multimedia.fontSize = "1.5em";

    }
    menu_multimedia.onmouseover = () => {
        menu_multimedia.style.display = "block";
        header_multimedia.fontSize = "1.8em";
    }
    menu_multimedia.onmouseout = () => {
        menu_multimedia.style.display = "none";
        header_multimedia.fontSize = "1.5em";

    }
}

/*----------------------------------------------------------------------------------------------*/

club_start();
team_start();
statistic_start();
multimedia_start();