
async function SendData(url, method, data) {
    try {
        const response = await fetch(url, {
            method: method,
            headers: {
                'Content-Type': 'application/json' // Indicate the content type
            },
            body: JSON.stringify(data)
        });

        // Check if the request was successful
        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        // Parse the JSON response
        const responseData = await response.json();
        console.log('Success:', responseData);
        return responseData;

    } catch (error) {
        console.error('Error:', error);
        // You can handle the error further or rethrow it
        throw error;
    }
}