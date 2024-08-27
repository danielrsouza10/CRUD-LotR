sap.ui.define([], function () {
    "use strict";

    const URL_TODAS_AS_RACAS = "https://localhost:7244/api/Raca/racas";
    const URL_OBTER_RACA = "https://localhost:7244/api/Raca/raca";
    const URL_POST_RACA = "https://localhost:7244/api/Raca/raca";
    const URL_PUT_RACA = "https://localhost:7244/api/Raca/raca";
    const URL_DELETE_RACA = "https://localhost:7244/api/Raca/raca";


    return {
        obterTodos: async function (filtros) {
            const urlRacas = new URL(URL_TODAS_AS_RACAS);

            Object.keys(filtros).forEach((key) => {
                urlRacas.searchParams.append(key, filtros[key]);
            });

            try {
                const response = await fetch(urlRacas.href);
                if (!response.ok) {
                    throw new Error("Sem resposta: " + response.statusText);
                }
                return response.json();
            } catch (erro) {
                throw new Error("Sem resposta: " + response.statusText);
            }
        },

        obterRaca: function (idRaca) {
            const urlRaca = new URL(`${URL_OBTER_RACA}/${idRaca}`);
            return fetch(urlRaca.href)
                .then((response) => {
                    if (!response.ok) {
                        throw new Error("Sem resposta: " + response.statusText);
                    }
                    return response.json();
                })
                .catch((erro) => {
                    throw new Error("Sem resposta: " + erro.message);
                });
        },

        adicionarRaca: async function (raca) {
            let urlRacas = new URL(URL_POST_RACA);

            try {
                const response = await fetch(urlRacas.href, {
                    method: "POST",
                    body: JSON.stringify(raca),
                    headers: {
                        "Content-type": "application/json; charset=UTF-8",
                    },
                });
                if (!response.ok) {
                    throw await response.json();
                }
                if (response.status == 200) {
                    return;
                }
                return await response.json();
            } catch (erro) {
                throw erro;
            }
        },

        editarRaca: async function (raca) {
            let urlRacas = new URL(URL_PUT_RACA);

            try {
                const response = await fetch(urlRacas.href, {
                    method: "PUT",
                    body: JSON.stringify(raca),
                    headers: {
                        "Content-type": "application/json; charset=UTF-8",
                    },
                });
                if (!response.ok) {
                    throw await response.json();
                }
                if (response.status == 200) {
                    return;
                }
                return await response.json();
            } catch (erro) {
                throw erro;
            }
        },
        removerRaca: async function (idRaca) {
            let urlRacas = new URL(URL_DELETE_RACA);
            try {
                const response = await fetch(urlRacas.href, {
                    method: "DELETE",
                    body: JSON.stringify(idRaca),
                    headers: {
                        "Content-type": "application/json; charset=UTF-8",
                    },
                });
                if (!response.ok) {
                    throw await response.json();
                }
                if (response.status == 200) {
                    return;
                }
                return await response.json();
            } catch (erro) {
                throw erro;
            }
        }
    };
});
