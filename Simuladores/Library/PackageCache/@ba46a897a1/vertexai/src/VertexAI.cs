/*
 * Copyright 2025 Google LLC
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace Firebase.VertexAI {

public class VertexAI {

  public static VertexAI DefaultInstance {
    get {
      throw new NotImplementedException();
    }
  }

  public static VertexAI GetInstance(string location = "us-central1") {
    throw new NotImplementedException();
  }
  public static VertexAI GetInstance(FirebaseApp app, string location = "us-central1") {
    throw new NotImplementedException();
  }

  public GenerativeModel GetGenerativeModel(
    string modelName,
    GenerationConfig? generationConfig = null,
    SafetySetting[] safetySettings = null,
    Tool[] tools = null,
    ToolConfig? toolConfig = null,
    ModelContent? systemInstruction = null,
    RequestOptions? requestOptions = null) {
      throw new NotImplementedException();
  }
}

}
