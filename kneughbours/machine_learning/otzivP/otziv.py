import numpy as np
from tensorflow import keras
from keras import layers

Dictionary = {
        "отлично": 0,
        "классно": 1 ,
        "хорошо": 2 ,
        "супер": 3,
        "прекрасно": 4, 
        "понравилось": 5, 
        "рекомендую": 6, 
        "удовлетворен": 7,           
        "плохо": 8,  
        "ужасно": 9,
        "отвратительно": 10,
        "разочарован": 11, 
        "не": 12 ,
        "понравилось-": 13, 
        "хуже": 14 ,
        "проблема": 15 
    }

def text_to_keys(text):
    text += " "
    mass = []
    t = ""
    for i in text:
        if i == " ":
            mass.append(t)
            t = ""
            continue
        t += i

    keys = []
    for i in mass:
        keys.append(Dictionary[i])
    return keys

x_trains= np.array([
    ["отлично классно супер"],
    ["понравилось прекрасно"],
    ["рекомендую удовлетворен"],
    ["плохо ужасно"],
    ["разочарован проблема"],
    ["не понравилось"],
    ["хуже отвратительно"],
])


x_train = []
for i in range(len(x_trains)):
    x_train.append(text_to_keys(x_trains[i][0]))
    
print(x_train)

y_train=np.array([1,1,1,0,0,0,0])

x_train = x_train / np.max(x_train, axis=0)

model = keras.Sequential([
    layers.Dense(10, activation="sigmoid", input_shape=(2,)),
    layers.Dense(5, activation="sigmoid"),
    layers.Dense(1, activation="softmax")
])

model.compile(
    optimizer="adam",
    loss="sparse_categorical_crossentropy",
    metrics=["accuracy"]
)

model.fit(x_train, y_train, epochs=1500, verbose=1)

for i in range(len(x_train)):
    user_input = np.array(text_to_keys(input()), dtype="float32")
    user_input = user_input / np.max(x_train, axis=0) 


    print(user_input)
    prediction = model.predict(user_input)
    predicted_class = np.argmax(prediction)

    classes = ["negative","positive"]
    print(f"otziv bil : {classes[predicted_class]}")