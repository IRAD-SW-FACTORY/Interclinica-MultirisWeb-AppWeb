

class INVOXMDComponent_LoginForm extends HTMLElement {


    constructor() {
        super()
        this._shadow = this.attachShadow({ mode: "open" })

        document.addEventListener(INVOX.eventTypeReport.LOGIN_ERROR, e => {
            this.restartLogin()
        });
        document.addEventListener(INVOX.eventTypeReport.LOGIN_SUCCESS, e => {
            this.showLogout()
        });
    }
    
    static get observedAttributes() {
        return ["host", "port", "use-remote-service", "username", "password" ]
    }

    getValue(param, { defaultValue }) {
        let value = this.getAttribute(param)
        if (!value || value == "undefined") {
            return defaultValue
        }
        return value
    }

    get iconCollection() {
        return {
            openEyeIcon: `
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-eye" viewBox="0 0 16 16">
                    <path d="M16 8s-3-5.5-8-5.5S0 8 0 8s3 5.5 8 5.5S16 8 16 8zM1.173 8a13.133 13.133 0 0 1 1.66-2.043C4.12 4.668 5.88 3.5 8 3.5c2.12 0 3.879 1.168 5.168 2.457A13.133 13.133 0 0 1 14.828 8c-.058.087-.122.183-.195.288-.335.48-.83 1.12-1.465 1.755C11.879 11.332 10.119 12.5 8 12.5c-2.12 0-3.879-1.168-5.168-2.457A13.134 13.134 0 0 1 1.172 8z"/>
                    <path d="M8 5.5a2.5 2.5 0 1 0 0 5 2.5 2.5 0 0 0 0-5zM4.5 8a3.5 3.5 0 1 1 7 0 3.5 3.5 0 0 1-7 0z"/>
                </svg>
            `,
            closeEyeIcon: `
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-eye-slash" viewBox="0 0 16 16">
                    <path d="M13.359 11.238C15.06 9.72 16 8 16 8s-3-5.5-8-5.5a7.028 7.028 0 0 0-2.79.588l.77.771A5.944 5.944 0 0 1 8 3.5c2.12 0 3.879 1.168 5.168 2.457A13.134 13.134 0 0 1 14.828 8c-.058.087-.122.183-.195.288-.335.48-.83 1.12-1.465 1.755-.165.165-.337.328-.517.486l.708.709z"/>
                    <path d="M11.297 9.176a3.5 3.5 0 0 0-4.474-4.474l.823.823a2.5 2.5 0 0 1 2.829 2.829l.822.822zm-2.943 1.299.822.822a3.5 3.5 0 0 1-4.474-4.474l.823.823a2.5 2.5 0 0 0 2.829 2.829z"/>
                    <path d="M3.35 5.47c-.18.16-.353.322-.518.487A13.134 13.134 0 0 0 1.172 8l.195.288c.335.48.83 1.12 1.465 1.755C4.121 11.332 5.881 12.5 8 12.5c.716 0 1.39-.133 2.02-.36l.77.772A7.029 7.029 0 0 1 8 13.5C3 13.5 0 8 0 8s.939-1.721 2.641-3.238l.708.709zm10.296 8.884-12-12 .708-.708 12 12-.708.708z"/>
                </svg>
            `
        }
    }

    connectedCallback() {
        this.render()
    }

    attributeChangedCallback(name, oldValue, newValue) {
        if (oldValue === newValue) {
            return
        }
        this.render()
    }

    render() {
        const useRemoteDictationService = this.getValue("use-remote-service", { defaultValue: "true"}) === "true"
        const host = useRemoteDictationService ? this.getValue("host", { defaultValue: ""}) : "localhost"
        const port = this.getValue("port", { defaultValue: ""})
        const username = this.getValue("username", { defaultValue: ""})
        const password = this.getValue("password", { defaultValue: ""})

        this.innerHTML = `<style>${this.getStyle()}</style>`
        this._shadow.innerHTML = `
            <style>
                ${this.getShadowStyle()}
            </style>
            
           
                <section>
<form>
                    <h4> Dictation Service </h4>
                    <label for="imd-dictation-service"> Connect to </label>                
                    <select name="imd-dictation-service">
                        <option value="local"> Local </option>
                        <option value="remote" ${useRemoteDictationService ? "selected" : ""}> Remote </option>
                    </select>

                    <label for="imd-host"> Host </label>
                    <input name="imd-host" type="text" placeholder="host.example.com" required value="${host}" ${!useRemoteDictationService ? "disabled" : ""}/>

                    <label for="imd-port"> Port </label>
                    <input name="imd-port" type="number" min="1" max="65535" placeholder="8443" required value="${port}"/>
                </section>
                <span></span>
                <section>
                    <h4> Credentials </h4>
                    <label for="imd-username"> Username </label>
                    <input name="imd-username" type="text" placeholder="Enter Username" required value="${username}"/>

                    <label for="imd-password"> Password </label>

                    <div class="invox-password-field">
                        <input name="imd-password" type="password" id="invox-password-input" placeholder="Enter Password" required value="${password}"/>
                        <span id="invox-password-toggler" class="invox-password-toggler">
                            ${this.iconCollection.closeEyeIcon}
                        </span>
                    </div>

                    <button id='invox-logout-button' class='invox-logout-button' type='button' hidden>Log Out</button>

                    <button id='invox-login-button' class='invox-login-button' type='submit'>
                        <span id="invox-loader" class="invox-loader" hidden></span>
                        Log In
                    </button>
                      </form>
                </section>
                 `

        this.setPasswordBehaviour()
        this.setLogoutBehaviour()
        this.setOnSubmit()
        this.setOnSelect()
    }

    setOnSelect() {
        const selectElement =  this._shadow.querySelector("select");
        selectElement.onchange = (e) => this.onChangeSelection(e);
    }

    setOnSubmit() {
        const formElement = this._shadow.querySelector("form");
        if (formElement == null)
            return;

        formElement.onsubmit = (event) => {
            event.preventDefault();
            this.validateForm();
        }
    }

    validateForm() {
        const formElement = this._shadow.querySelector("form");
        const user = formElement["imd-username"].value;
        if (user === "") {
            return;
        }
        const password = formElement["imd-password"].value;
        if (password === "") {
            return;
        }
        const useDictationService = formElement["imd-dictation-service"].value === "remote";
        const host = formElement["imd-host"].value;
        if (host === "") {
            return;
        }
        const port = formElement["imd-port"].value;
        if (port === "") {
            return;
        }

        if (!this.onClickLogin) {
            return;
        }
        
        this.showLoading();
        this.onClickLogin({ user, password }, { host, port, useDictationService })
            .catch(() => {
                this.restartLogin();
            })
    }

    onClickLogin(credentials, connectionSettings) {
        console.warn("This function is customizable.")
    }

    setLogoutBehaviour() {
        const logoutButton = this._shadow.getElementById("invox-logout-button")
        logoutButton && (logoutButton.onclick = () => {
            this.onClickLogout && this.onClickLogout()
            this.restartLogin()
        })
    }

    restartLogin() {
        this.removeLoading()

        const loginButton = this._shadow.getElementById("invox-login-button")
        loginButton.disabled = false
        loginButton.hidden = false

        const logoutButton = this._shadow.getElementById("invox-logout-button")
        logoutButton.hidden = true
    }

    showLoading() {
        this.setLoading();

        const loginButton = this._shadow.getElementById("invox-login-button")
        loginButton.disabled = true
    }

    showLogout() {
        const loginButton = this._shadow.getElementById("invox-login-button")
        loginButton.hidden = true

        const logoutButton = this._shadow.getElementById("invox-logout-button")
        logoutButton.hidden = false
    }

    setPasswordBehaviour() {
        const passwordInput = this._shadow.getElementById("invox-password-input")
        const passwordToogle = this._shadow.getElementById("invox-password-toggler")
        passwordToogle.onclick = () => {
            if (passwordInput.type == "password") {
                passwordInput.setAttribute("type", "text")
                passwordToogle.innerHTML = this.iconCollection.openEyeIcon
                return
            }
            passwordInput.setAttribute("type", "password")
            passwordToogle.innerHTML = this.iconCollection.closeEyeIcon
        }
    }

    getStyle() {
        return `
            invox-login-form {
                display: flex;
                flex-direction: column;
                width: fit-content;
                max-width: fit-content !important;
                height: auto;
            }
        `
    }

    onChangeSelection(e) {

        if (e.currentTarget.value === "local") {
            const formElement = this._shadow.querySelector("form")

            this.setAttribute("use-remote-service", false)
            this.setAttribute("host", formElement["imd-host"].value)
            this.setAttribute("port", formElement["imd-port"].value)
            this.setAttribute("username", formElement["imd-username"].value)
            this.setAttribute("password", formElement["imd-password"].value)

            this.useRemoteDictationService = false
            return
        }

        this.setAttribute("use-remote-service", true);
    }

    getShadowStyle() {

        const lightpurple = "#dce1f0"
        const purple = "#d2d7ee"
        const darkpurple = "#415491"

        const lightgreen = "#bbeee1"
        const green = "#a6e2d3"
        const darkgreen = "#4c6c61"

        const lightgray = "#f3f3f3"
        const gray = "#d1d1d1"
        const darkgray = "gray"

        return `
            *,
            *::before,
            *::after {
                box-sizing: border-box;
            }

            form, section {
                width: 100%;
                display: flex;
            }

            form {
                flex-direction: row;
                box-shadow: 0 3px 10px rgb(0 0 0 / 0.2);
                border-radius: 0.25em;
                background-color: white;
                flex-wrap: wrap;
            }
            
            section {
                flex-direction: column;
                flex: 1;
                padding: 1rem;
                padding-top: 0.5rem;
                row-gap: 5px;
            }

            form > span {
                width: 1.5px;
                display: block;
                margin-block: 0.6rem;
                background-color: ${lightgray};
            }

            h4 {
                margin: 0;
                font-weight: 600
            }

            label {
                font-size: 0.7rem;
                margin-left: 0.4rem;
            }

            select {
                width: 100%;
                height: 2rem;
                max-height: 2rem;
                padding-inline: 3rem 1rem;
                cursor: pointer;
                -webkit-appearance: none;
                -moz-appearance: none;
                appearance: none;
                background: url("data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiA/PjxzdmcgZmlsbD0ibm9uZSIgaGVpZ2h0PSIyNCIgc3Ryb2tlLXdpZHRoPSIxLjUiIHZpZXdCb3g9IjAgMCAyNCAyNCIgd2lkdGg9IjI0IiB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciPjxwYXRoIGQ9Ik02IDlMMTIgMTVMMTggOSIgc3Ryb2tlPSJjdXJyZW50Q29sb3IiIHN0cm9rZS1saW5lY2FwPSJyb3VuZCIgc3Ryb2tlLWxpbmVqb2luPSJyb3VuZCIvPjwvc3ZnPg==") no-repeat 95% center;
                background-size: 16px 16px;
                direction: rtl;
                background-color: ${lightgray};
                outline: none;
                border: solid 1.5px ${gray};
                border-radius: 0.3rem;
                font-size: 0.8rem;
                text-align: left;
                white-space: normal;
                margin: 0;
                text-overflow: ellipsis;
                white-space: nowrap;
            }

            input, .invox-password-field {
                display: flex;
                flex: 1;
                max-height: 2rem;
                font-size: 0.8rem;
                padding: 0.4rem;
                margin: 0;
                outline: none;
                background-color: transparent;
                border: solid 1.5px ${gray};
                border-radius: 0.3rem;
            }

            input[disabled],
            button[disabled] {
                cursor: not-allowed;
            }

            .invox-password-field {
                display: flex;
                height: fit-content;
                flex: 1;
                justify-content: center;
                align-items: center;
                padding: 0;
                margin: 0;
            }

            .invox-password-field > input,
            .invox-password-field > input:focus {
                border: none;
                outline: none;
                width: 100%;
                text-overflow: ellipsis;
                white-space: nowrap;
            }

            input:focus,
            .invox-password-field:focus-within {
                border: solid 1.5px ${darkgray};
                background-color: solid 1.5px ${darkgray};
            }

            button {
                width: 100%;
                height: 2.5rem;
                outline: none;
                border: none;
                margin-top: 0.6rem;
                padding: 0.6rem;
                border-radius: 0.3rem;
                font-weight: 600;
                font-size: 1rem;
                cursor: pointer;
            }

            .invox-login-button {
                background-color: ${lightgreen};
                color: ${darkgreen};
            }

            .invox-login-button:hover, .invox-login-button:focus {
                background-color: ${green};
            }

            .invox-logout-button {
                background-color: ${lightpurple};
                color: ${darkpurple};
            }
            .invox-logout-button:hover, .invox-logout-button:focus {
                background-color: ${purple};
            }

            .invox-password-toggler {
                display: flex;
                height: 100%;
                justify-content: center;
                align-items: center;
                cursor: pointer;
                padding-inline: 0.5rem;
            }

            .invox-loader {
                width: 0.8rem;
                height: 0.8rem;
                border: 3px solid #47706982;
                border-bottom-color: transparent;
                border-radius: 50%;
                display: inline-block;
                box-sizing: border-box;
                animation: rotation 1s linear infinite;
            }

            .invox-loader[hidden] {
                display:none;
            }
        
            @keyframes rotation {
                0% {
                    transform: rotate(0deg);
                }
                100% {
                    transform: rotate(360deg);
                }
            } 
        `
    }

    setLoading() {
        const spinnerElement = this._shadow.getElementById("invox-loader")
        spinnerElement.hidden = false
    }

    removeLoading() {
        const spinnerElement = this._shadow.getElementById("invox-loader")
        spinnerElement.hidden = true
    }
}

window.customElements.define("invox-login-form", INVOXMDComponent_LoginForm)