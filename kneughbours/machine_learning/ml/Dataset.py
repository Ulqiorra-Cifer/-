import numpy as np
from tensorflow import keras
from tensorflow.keras import layers


x_train = np.array([
    [30, 40, 709, 3],   #т в д с
    [18, 85, 710, 8],   
    [0, 90, 709, 10],   
    [22, 60, 710, 2],
    [28, 38, 709, 4],   
    [15, 82, 710, 9],   
    [2, 87, 709, 12],   
    [20, 55, 710, 3]     
], dtype="float32")

y_train = np.array([0, 1, 2, 3, 0, 1, 2, 3])  # метки (0=солнечно, 1=дождь, 2=снег, 3=облачно)

x_train = x_train / np.max(x_train, axis=0)

model = keras.Sequential([
    layers.Dense(16, activation="sigmoid", input_shape=(4,)),  # 4 признака
    layers.Dense(16, activation="sigmoid"),  # 4 признака
    layers.Dense(4, activation="softmax")  # 4 класса погоды
])

model.compile(
    optimizer="adam",
    loss="sparse_categorical_crossentropy",
    metrics=["accuracy"]
)

model.fit(x_train, y_train, epochs=2500, verbose=1)


for i in range(len(x_train)):
    user_input = np.array([x_train[i]], dtype="float32")
    user_input = user_input / np.max(x_train, axis=0) 

    prediction = model.predict(user_input)
    predicted_class = np.argmax(prediction)

    classes = ["солнечно", "дождь", "снег", "облачно"]
    print(f"Прогноз погоды: {classes[predicted_class]}")