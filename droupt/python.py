import numpy as np
from tensorflow import keras
from keras import layers
from keras.preprocessing.sequence import pad_sequences

# Словарь
Dictionary = {
    "отлично": 0, "классно": 1, "хорошо": 2, "супер": 3,
    "прекрасно": 4, "понравилось": 5, "рекомендую": 6, "удовлетворен": 7,
    "плохо": 8, "ужасно": 9, "отвратительно": 10, "разочарован": 11,
    "не": 12, "понравилось-": 13, "хуже": 14, "проблема": 15
}

# Перевод текста в числа
def text_to_keys(text):
    words = text.split()
    return [Dictionary[w] for w in words if w in Dictionary]

# Тренировочные тексты
x_texts = [
    "отлично классно супер",
    "понравилось прекрасно",
    "рекомендую удовлетворен",
    "плохо ужасно",
    "разочарован проблема",
    "не понравилось",
    "хуже отвратительно",
]

y_train = np.array([1, 1, 1, 0, 0, 0, 0])

# Преобразуем тексты
x_train = [text_to_keys(t) for t in x_texts]

# Делаем одинаковую длину (например, maxlen = 3)
x_train = pad_sequences(x_train, padding='post')

# Модель
model = keras.Sequential([
    layers.Embedding(input_dim=len(Dictionary), output_dim=8, input_length=x_train.shape[1]),
    layers.Flatten(),
    layers.Dense(10, activation="relu"),
    layers.Dropout(rate=0.5),
    layers.Dense(1, activation="sigmoid")
])

model.compile(optimizer="adam", loss="binary_crossentropy", metrics=["accuracy"])

# Обучение
model.fit(x_train, y_train, epochs=2000, verbose=1)

# --- Предсказание ---
classes = ["negative", "positive"]

while True:
    text = input("Введите отзыв: ")
    seq = pad_sequences([text_to_keys(text)], maxlen=x_train.shape[1], padding='post')
    prediction = model.predict(seq)[0][0]
    print(f"Отзыв: {classes[int(prediction > 0.5)]}\n")
