const ApiInstance = (function () {
    let instance; // Private instance

    class Api {
        AUTH_KEY = "TOKEN";
        BASE_URL = "http://localhost:5223/";

        constructor() {
            if (instance) return instance;
            instance = this;
        }

        getHeaders() {
            const token = localStorage.getItem(this.AUTH_KEY);
            let headers = { "Content-Type": "application/json" };
            if (token) headers["Authorization"] = `${token}`;
            return headers;
        }

        request(url, method = "GET",data = null, headers = {}) {
            url = `${this.BASE_URL}${url}`;

            return new Promise((resolve, reject) => {
                $.ajax({
                    url,
                    method,
                    data: data ? JSON.stringify(data) : null,
                    contentType: "application/json",
                    headers: { ...this.getHeaders(), ...headers },
                    success: (response) => resolve(response),
                    error: (xhr, status, error) => reject({ xhr, status, error })
                });
            })
        }

        get(url) {
            return this.request(url, "GET", headers = {});
        }
    
        post(url, data = null) {
            return this.request(url, "POST", data, headers = {});
        }
    
        put(url, data = null) {
            return this.request(url, "PUT", data, headers = {});
        }
    
        delete(url) {
            return this.request(url, "DELETE", headers = {});
        }
    
        patch(url, data = null) {
            return this.request(url, "PATCH", data, headers = {});
        }
    }

    return Api;
})();
