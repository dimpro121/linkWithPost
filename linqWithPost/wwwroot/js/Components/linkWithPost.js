document.addEventListener('DOMContentLoaded', function () {
    const links = document.querySelectorAll('.link-with-post');

    links.forEach(link => {
        link.addEventListener('click', async function (event) {
            event.preventDefault();

            const url = this.getAttribute('href');
            const callbackName = this.getAttribute('data-callback');
            const dataName = this.getAttribute('data-name');

            let requestData = null;
            if (dataName && window[dataName] !== undefined) {
                requestData = window[dataName];
            }

            try {
                const response = await fetch(url, {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: requestData !== null ? JSON.stringify(requestData) : null
                });

                if (response.ok) {
                    if (callbackName && typeof window[callbackName] === 'function') {
                        const result = await response.text();
                        window[callbackName](result);
                    } else if (callbackName) {
                        console.warn(`Callback '${callbackName}' не найден`);
                    }
                } else {
                    window[callbackName](result);
                    console.warn(`Callback '${callbackName}' не найден`);
                }
            } catch (error) {
                console.error('Ошибка:', error);
            }
        });
    });
});