import numpy as np
from  tensorflow import keras
from keras import layers

x_train= np.array([
    [15,80,2,100,98,33,17,100000],
    [349,789,30,10000000,98,648,17,900000],
    [99,23,9,100,1500000,573,98,70000000],
    [1376,345,57,31000000,542,38,17,110000000],
    [2231,1200,80,2800000000,451,83,17,23000000]
], dtype="float32")

y_train=np.array([0,1,0,1,1])

x_train = x_train / np.max(x_train, axis=0)

model = keras.Sequential([
    layers.Dense(16, activation="sigmoid", input_shape=(8,)),  # 4 признака
    layers.Dense(2, activation="softmax")  # 4 класса погоды
])

model.compile(
    optimizer="adam",
    loss="sparse_categorical_crossentropy",
    metrics=["accuracy"]
)

model.fit(x_train, y_train, epochs=2000, verbose=1)

for i in range(len(x_train)):
    user_input = np.array([[int(input()),int(input()),int(input()),int(input()),int(input()),int(input()),int(input()),int(input()),]], dtype="float32")
    user_input = user_input / np.max(x_train, axis=0) 


    print(user_input)
    prediction = model.predict(user_input)
    predicted_class = np.argmax(prediction)

    classes = ["lose","win"]
    print(f"Прогноз матча: {classes[predicted_class]}")